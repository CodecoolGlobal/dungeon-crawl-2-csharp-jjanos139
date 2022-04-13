Shader "Custom/ObjectShader"
{
    Properties
    {
        [_IntRange] _StencilID ("Stencil ID", Range(0, 255)) = 0
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Metallic("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry"
        }

        Pass
        {
            //Blend Zero One
            //ZWrite Off

            Stencil
            {
                Ref [_StencilID]
                Comp Equal
                //Pass Replace
                //Fail Keep
            }
        }
    }
}
