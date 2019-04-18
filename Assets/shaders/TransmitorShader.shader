Shader "Custom/TransmitorShader" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Alpha ("Alpha (A)", 2D) = "white" {}
        //_BumpMap ("Bump (RGB) Illumin (A)", 2D) = "bump" {}
    }
    SubShader {     
        //UsePass "Self-Illumin/VertexLit/BASE"
        //UsePass "Bumped Diffuse/PPL"
        // Ambient pass
        Tags {"RenderType" = "Transparent" "Queue" = "Transparent"}

        ZWrite Off

        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask RGB

       Pass {
        Name "BASE"
        Tags {"LightMode" = "Always" /* Upgrade NOTE: changed from PixelOrNone to Always */}
        Color [_PPLAmbient]
        SetTexture [_BumpMap] {
            constantColor (.5,.5,.5)
            combine constant lerp (texture) previous
            }
        SetTexture [_MainTex] {
            constantColor [_Color]
            Combine texture * previous DOUBLE, texture*constant
            }
        SetTexture [_Alpha] {
        	Combine previous, texture
        	}
        }
    // Vertex lights
    Pass {
        Name "BASE"
        Tags {"LightMode" = "Vertex"}
        Material {
            Diffuse [_Color]
            Emission [_PPLAmbient]
            Shininess [_Shininess]
            Specular [_SpecColor]
            }
        SeparateSpecular On
        Lighting On
        Cull Off
        SetTexture [_BumpMap] {
            constantColor (.5,.5,.5)
            combine constant lerp (texture) previous
            }
       SetTexture [_MainTex] {

            Combine texture * previous DOUBLE, texture*primary
            }
        }
    } 
    FallBack "Diffuse", 1
}
