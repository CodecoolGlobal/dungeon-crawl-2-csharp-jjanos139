Shader "Custom/ViewShader"
{
    Properties
    {
        [_IntRange] _StencilID("Stencil ID", Range(0, 255)) = 0
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
        SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry-100"
        }

        Pass
        {
            //Blend Zero One
            ColorMask 0
            ZWrite Off

            Stencil
            {
                Ref [_StencilID]
                //Comp Always
                Pass Replace
                //Fail Keep
            }
        }
    }
}
