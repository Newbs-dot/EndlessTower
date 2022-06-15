Shader "Unlit/Tutorial"
{
    Properties { //input
        _ColorA ("Color A", Color) = (1,1,1,1)
        _ColorB ("Color B", Color) = (1,1,1,1)
        _ColorStart ("Color Start", Range(0,1)) = 0
        _ColorEnd ("Color End", Range(0,1)) = 1
        
    }
    SubShader {
        Tags { "RenderType"="Opaque" }

        Pass {

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            

            #include "UnityCG.cginc"

            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;

            struct MeshData { // per-vertex
                float4 vertex : POSITION; //vertex position
                float3 normals : NORMAL;
                //float4 tangent : TANGENT;
                //float4 color: COLOR;
                float2 uv0 : TEXCOORD0; //uv coordinates

            };

            struct v2f {
                //float2 uv : TEXCOORD0;
                float3 normal : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD1;
            };

            
            v2f vert (MeshData v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);
               // o.uv = (v.uv0 + _Offset) * _Scale;
                o.uv = v.uv0;
                return o;
            }

            float InverseLerp(float a, float b, float v){
                return (v-a)/(b-a);
            }

            float4 frag (v2f i) : SV_Target {
                float t = InverseLerp(_ColorStart,_ColorEnd, i.uv.x);
                float4 outColor = lerp(_ColorA, _ColorB, t);

                return outColor;
            }
            ENDCG
        }
    }
}
