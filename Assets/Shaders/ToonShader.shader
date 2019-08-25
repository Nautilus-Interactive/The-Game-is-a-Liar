Shader "Unlit/ToonShader"
{
    Properties
    {
		[HideInInspector]_MainTex("Base (RGB)", 2D) = "white" {}
		_OutlineThickness ("Outline Thickness", Range(0.005,0.0025)) = 0.001
		_ColorCount("Count", int) = 8
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
			HLSLPROGRAM
			#include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/SurfaceInput.hlsl"
			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			
			TEXTURE2D(_CameraDepthTexture);
			SAMPLER(sampler_CameraDepthTexture);

			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);

			float _OutlineThickness;
			int _ColorCount;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				UNITY_VERTEX_OUTPUT_STEREO
            };
			
			float SampleDepth(float2 uv)
			{
#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
				return SAMPLE_TEXTURE2D_ARRAY(_CameraDepthTexture, sampler_CameraDepthTexture, uv, unity_StereoEyeIndex).r;
#else
				return SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, uv);
#endif
			}

			float sobel(float2 uv)
			{
				float2 outline = float2(_OutlineThickness, _OutlineThickness);

				float hr = 0;
				float vt = 0;

				hr += SampleDepth(uv + float2(-1.0, -1.0) * outline) *  1.0;
				hr += SampleDepth(uv + float2(1.0, -1.0) * outline) * -1.0;
				hr += SampleDepth(uv + float2(-1.0, 0.0) * outline) *  2.0;
				hr += SampleDepth(uv + float2(1.0, 0.0) * outline) * -2.0;
				hr += SampleDepth(uv + float2(-1.0, 1.0) * outline) *  1.0;
				hr += SampleDepth(uv + float2(1.0, 1.0) * outline) * -1.0;

				vt += SampleDepth(uv + float2(-1.0, -1.0) * outline) *  1.0;
				vt += SampleDepth(uv + float2(0.0, -1.0) * outline) *  2.0;
				vt += SampleDepth(uv + float2(1.0, -1.0) * outline) *  1.0;
				vt += SampleDepth(uv + float2(-1.0, 1.0) * outline) * -1.0;
				vt += SampleDepth(uv + float2(0.0, 1.0) * outline) * -2.0;
				vt += SampleDepth(uv + float2(1.0, 1.0) * outline) * -1.0;

				return sqrt(hr * hr + vt * vt);
			}

            v2f vert (appdata v)
            {
                v2f o = (v2f)0;
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(0);

				VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);
				o.vertex = vertexInput.positionCS;
				o.uv = v.uv;

                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

				float s = pow(1 - saturate(sobel(i.uv)), 50);

				half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
				
				col = pow(col, 0.4545);
				float3 c = RgbToHsv(col);
				c.z = round(c.z * _ColorCount) / _ColorCount;
				col = float4(HsvToRgb(c), col.a);
				col = pow(col, 2.2);

				return col * s;
            }

			#pragma vertex vert
			#pragma fragment frag

			ENDHLSL
        }
    }
	FallBack "Diffuse"
}
