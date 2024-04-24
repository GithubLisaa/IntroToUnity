Shader "Unlit/StarField"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        
            // -----------------------------------
            // -- My Custom properties -----------
            // -----------------------------------
        _TotalTime ("TotalTime", float) = 0.0

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;            
            float _TotalTime; // passé depuis le script unity

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            // -----------------------------------
            // -- StarField Shader ---------------
            // -----------------------------------

            #define LAYERS 6.0

            float hash21( float2 id ){
               id = frac( id * float2( 123.34 , 456.21 ) );
               id += dot( id , id + 45.321);
               return frac( id.x * id.y );
            }
 
            float2x2 rotate( float a ){
                float s = sin(a);
                float c = cos(a);
                return float2x2(c, -s , s , c);
            }
 
            // == creation d'une étoile
            float star( float2 uv , float flare , float rand ){
                float d = length(uv);
                float starLight = 0.02/d;
 
                float2 rotUv = mul(uv,rotate( _Time.y ));
                float rotRays = max( 0.0 , 1.0 - abs( rotUv.x * rotUv.y * 1000.0 ) ) * 0.05 * flare;
    
                float allLight =  starLight + rotRays;    
                allLight *= smoothstep( 0.009 , 0.005 , d ); // mhhh

                return max( allLight , 0.0 );
            }

            float3 starLayer( float2 uv , float layerSeed ){
                float2 id = floor(uv);
                float2 gv = frac(uv);
    
                float3 col = 0.0;
    
                for( int y=-1; y<=1; y++ ) 
                {
                    for( int x=-1; x<=1; x++ ) 
                    {
                        float2 offset = float2(x , y);
                        float2 thisId = offset + id;
            
                        float starRand = hash21( thisId + layerSeed );
                        float size = frac(starRand * 405.32 );
                        float2 starPos = gv - offset - float2( sin(starRand * 12.3423) * 0.5 + 0.5 , frac( starRand * 90.123 ) ) + 0.5;
            
                        float thisStar = star( starPos , smoothstep( .9 , 1.0, 1.0 ) , starRand  );
            
                        float3 color = sin( float3(0.6 , 0.3 , 0.9) * frac( starRand * 2342.2 ) * 123.2 ) * 0.5 + 0.5;
                        color = max( color, float3( 0.4 , 1.0 , 0.4 ) );
            
                        color *= float3(1.0 , 0.6 , 1.0 + size );
            
                        col += thisStar * size * color;
                    }
                }
    
                return col;
            }
 
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float t = _TotalTime ; //_Time.y on veut recupérer le TotalTime de Unity mais ici je prefere manipuler le temps depuis mon script
                
                float distFade = 1.0;
                float3 col = 0.0;

                for( float x = 0.0; x<1.0; x += 1.0/LAYERS)
                {
                    float depth = frac( x );
                    float fade = depth;
                    float scale = lerp( 10.0 , 0.5 , depth );
                    float layerRand = hash21( float2(scale , depth) ) ;
                    col += starLayer( uv * scale + float2( 0.0 , t * -1.0 ) , layerRand ) * fade;
                }
    
                return float4(col, 1.0);
            }

            ENDCG
        }
    }
}
