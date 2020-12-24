using System;
using System.Text;

namespace XAbcPaymentSdkCore.Util
{
	// Token: 0x0200002C RID: 44
	public class Base64
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000B238 File Offset: 0x0000A238
		private char NextUsefulChar
		{
			get
			{
				char c = '_';
				while (!this.isUsefulChar(c))
				{
					c = this.mString[this.mIndex++];
				}
				return c;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000B280 File Offset: 0x0000A280
		public string encode(byte[] data)
		{
			int num = data.Length * 4 / 3 + 4;
			StringBuilder stringBuilder = new StringBuilder(num * 77 / 76);
			int num2 = data.Length;
			int i = 0;
			while (i < num2 - 2)
			{
				int num3 = this.convertUnsignedByteToInt(data[i++]);
				num3 <<= 8;
				num3 |= this.convertUnsignedByteToInt(data[i++]);
				num3 <<= 8;
				num3 |= this.convertUnsignedByteToInt(data[i++]);
				byte b = (byte)(63 & num3);
				num3 >>= 6;
				byte b2 = (byte)(63 & num3);
				num3 >>= 6;
				byte b3 = (byte)(63 & num3);
				num3 >>= 6;
				byte b4 = (byte)(63 & num3);
				stringBuilder.Append(this.mapByteToChar(b4));
				stringBuilder.Append(this.mapByteToChar(b3));
				stringBuilder.Append(this.mapByteToChar(b2));
				stringBuilder.Append(this.mapByteToChar(b));
			}
			if (i == num2 - 1)
			{
				int num3 = this.convertUnsignedByteToInt(data[i++]);
				num3 <<= 4;
				byte b3 = (byte)(63 & num3);
				num3 >>= 6;
				byte b4 = (byte)(63 & num3);
				stringBuilder.Append(this.mapByteToChar(b4));
				stringBuilder.Append(this.mapByteToChar(b3));
				stringBuilder.Append("==");
			}
			if (i == num2 - 2)
			{
				int num3 = this.convertUnsignedByteToInt(data[i++]);
				num3 <<= 8;
				num3 |= this.convertUnsignedByteToInt(data[i++]);
				num3 <<= 2;
				byte b2 = (byte)(63 & num3);
				num3 >>= 6;
				byte b3 = (byte)(63 & num3);
				num3 >>= 6;
				byte b4 = (byte)(63 & num3);
				stringBuilder.Append(this.mapByteToChar(b4));
				stringBuilder.Append(this.mapByteToChar(b3));
				stringBuilder.Append(this.mapByteToChar(b2));
				stringBuilder.Append("=");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000B484 File Offset: 0x0000A484
		public byte[] decode(string data)
		{
			this.mString = data;
			this.mIndex = 0;
			int num = 0;
			int length = this.mString.Length;
			for (int i = 0; i < length; i++)
			{
				if (this.isUsefulChar(this.mString[i]))
				{
					num++;
				}
			}
			int num2 = num * 3 / 4;
			byte[] array = new byte[num2];
			int num3 = 0;
			while (num3 + 2 < num2)
			{
				int num4 = this.mapCharToInt(this.NextUsefulChar);
				num4 <<= 6;
				num4 |= this.mapCharToInt(this.NextUsefulChar);
				num4 <<= 6;
				num4 |= this.mapCharToInt(this.NextUsefulChar);
				num4 <<= 6;
				num4 |= this.mapCharToInt(this.NextUsefulChar);
				array[num3 + 2] = (byte)(num4 & 255);
				num4 >>= 8;
				array[num3 + 1] = (byte)(num4 & 255);
				num4 >>= 8;
				array[num3] = (byte)(num4 & 255);
				num3 += 3;
			}
			if (num3 == num2 - 1)
			{
				int num4 = this.mapCharToInt(this.NextUsefulChar);
				num4 <<= 6;
				num4 |= this.mapCharToInt(this.NextUsefulChar);
				num4 >>= 4;
				array[num3] = (byte)(num4 & 255);
			}
			if (num3 == num2 - 2)
			{
				int num4 = this.mapCharToInt(this.NextUsefulChar);
				num4 <<= 6;
				num4 |= this.mapCharToInt(this.NextUsefulChar);
				num4 <<= 6;
				num4 |= this.mapCharToInt(this.NextUsefulChar);
				num4 >>= 2;
				array[num3 + 1] = (byte)(num4 & 255);
				num4 >>= 8;
				array[num3] = (byte)(num4 & 255);
			}
			return array;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000B66C File Offset: 0x0000A66C
		private int mapCharToInt(char c)
		{
			int result;
			if (c >= 'A' && c <= 'Z')
			{
				result = (int)(c - 'A');
			}
			else if (c >= 'a' && c <= 'z')
			{
				result = (int)(c - 'a' + '\u001a');
			}
			else if (c >= '0' && c <= '9')
			{
				result = (int)(c - '0' + '4');
			}
			else if (c == '+')
			{
				result = 62;
			}
			else
			{
				if (c != '/')
				{
					throw new ArgumentException(c + " is not a valid Base64 character.");
				}
				result = 63;
			}
			return result;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000B70C File Offset: 0x0000A70C
		private char mapByteToChar(byte b)
		{
			char result;
			if (b < 26)
			{
				result = (char)(65 + b);
			}
			else if (b < 52)
			{
				result = (char)(97 + (b - 26));
			}
			else if (b < 62)
			{
				result = (char)(48 + (b - 52));
			}
			else if (b == 62)
			{
				result = '+';
			}
			else
			{
				if (b != 63)
				{
					throw new ArgumentException("Byte " + b + " is not a valid Base64 value");
				}
				result = '/';
			}
			return result;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000B7A0 File Offset: 0x0000A7A0
		private bool isUsefulChar(char c)
		{
			return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '+' || c == '/';
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000B7E0 File Offset: 0x0000A7E0
		private int convertUnsignedByteToInt(byte b)
		{
			int result;
			if (b >= 0)
			{
				result = (int)b;
			}
			else
			{
				result = 256 + (int)b;
			}
			return result;
		}

		// Token: 0x040000FC RID: 252
		private const int LOWER_CASE_A_VALUE = 26;

		// Token: 0x040000FD RID: 253
		private const int ZERO_VALUE = 52;

		// Token: 0x040000FE RID: 254
		private const int PLUS_VALUE = 62;

		// Token: 0x040000FF RID: 255
		private const int SLASH_VALUE = 63;

		// Token: 0x04000100 RID: 256
		private const int SIX_BIT_MASK = 63;

		// Token: 0x04000101 RID: 257
		private const int EIGHT_BIT_MASK = 255;

		// Token: 0x04000102 RID: 258
		private string mString;

		// Token: 0x04000103 RID: 259
		private int mIndex = 0;
	}
}
