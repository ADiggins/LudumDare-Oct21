Shader "Unlit/exShader/benis"
{
    Properties
    {
        //declare public properties
        _MainTex ("Texture", 2D) = "white" {}
        _TintColor("Tint Colour", color) = (1,1,1,1)
        _Transparency("Transparency", Range(0.0, 1.0)) = 0.1
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
        
        Zwrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TintColor;
            float _Transparency;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }   

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                // the final colour is the texture * the tint uv
                // + will add the tint to the texture ie the bit values will be additive
                // that means you can just get a white box easily
                fixed4 col = tex2D(_MainTex, i.uv) * _TintColor;
                col.a = _Transparency;
                return col;
            }
            ENDCG
        }
    }
}
