﻿Shader "Custom/ColoredPoint"
{
    SubShader
    {

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        struct Input
        {
			float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			o.Albedo.rgb = IN.worldPos.xyz * 0.5f + 0.5f;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
