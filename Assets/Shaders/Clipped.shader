Shader "Sprites/Clipped"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_Color("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		_ClipX("Clip X", Range(0.0, 2000.0)) = 0
		_ClipY("Clip Y", Range(0.0, 1000.0)) = 0
		_Width("Width", Range(0.0, 2000.0)) = 2000
		_Height("Height", Range(0.0, 1000.0)) = 1000
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile _ PIXELSNAP_ON
#include "UnityCG.cginc"

		struct appdata_t
	{
		float4 vertex   : POSITION;
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex    : SV_POSITION;
		fixed4 color : COLOR;
		half2 texcoord   : TEXCOORD0;
		float2 screenPos : TEXCOORD1;
	};

	fixed4 _Color;

	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
		OUT.texcoord = IN.texcoord;
		OUT.color = IN.color * _Color;
#ifdef PIXELSNAP_ON
		OUT.vertex = UnityPixelSnap(OUT.vertex);
#endif
		OUT.screenPos.xy = ComputeScreenPos(OUT.vertex).xy * _ScreenParams.xy;

		return OUT;
	}

	sampler2D _MainTex;
	float _Width;
	float _Height;
	float _ClipX;
	float _ClipY;

	fixed4 frag(v2f IN) : SV_Target
	{
		if ((IN.screenPos.x < _ClipX) || (IN.screenPos.x > _ClipX + _Width) || (IN.screenPos.y < _ClipY) || (IN.screenPos.y > _ClipY + _Height))
		{
			fixed4 transparent = fixed4(0, 0, 0, 0);
			return transparent;
		}

	fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
	c.rgb *= c.a;
	return c;
	}
		ENDCG
	}
	}
}