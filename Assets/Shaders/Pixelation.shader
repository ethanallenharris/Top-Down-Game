Shader "Hidden/Pixelation "
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _pixels("Resolution", int) = 1080
        _pw("Pixel Width", float) = 4
        _ph("Pixel Height", float) = 4
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float _pixels;
            float _pw;
            float _ph;
            float _dx;
            float _dy;
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                _dx = _pw * (1 / _pixels);
                _dy = _ph * (1 / _pixels);
                float2 coord = float2(_dx * floor(i.uv.x / _dx), _dy * floor(i.uv.y / _dy));
                fixed4 col = tex2D(_MainTex, coord);
                col.rgb = round(col.rgb * 10) / 10; // round color values to 0, 0.5, 0.75, or 1
                col.a = 1; // set alpha value to 1
                return col;
            }
            ENDCG
        }
    }
}
