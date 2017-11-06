using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SQLHTMLDecode
{
		public class WebUtility
		{
			private static class HtmlEntities
			{
				private static readonly string[] _entitiesList = new string[]
				{
					"'-#39",
					"\"-quot",
					"&-amp",
					"'-apos",
					"<-lt",
					">-gt",
					"\u00a0-nbsp",
					"�-iexcl",
					"�-cent",
					"�-pound",
					"�-curren",
					"�-yen",
					"�-brvbar",
					"�-sect",
					"�-uml",
					"�-copy",
					"�-ordf",
					"�-laquo",
					"�-not",
					"�-shy",
					"�-reg",
					"�-macr",
					"�-deg",
					"�-plusmn",
					"�-sup2",
					"�-sup3",
					"�-acute",
					"�-micro",
					"�-para",
					"�-middot",
					"�-cedil",
					"�-sup1",
					"�-ordm",
					"�-raquo",
					"�-frac14",
					"�-frac12",
					"�-frac34",
					"�-iquest",
					"�-Agrave",
					"�-Aacute",
					"�-Acirc",
					"�-Atilde",
					"�-Auml",
					"�-Aring",
					"�-AElig",
					"�-Ccedil",
					"�-Egrave",
					"�-Eacute",
					"�-Ecirc",
					"�-Euml",
					"�-Igrave",
					"�-Iacute",
					"�-Icirc",
					"�-Iuml",
					"�-ETH",
					"�-Ntilde",
					"�-Ograve",
					"�-Oacute",
					"�-Ocirc",
					"�-Otilde",
					"�-Ouml",
					"�-times",
					"�-Oslash",
					"�-Ugrave",
					"�-Uacute",
					"�-Ucirc",
					"�-Uuml",
					"�-Yacute",
					"�-THORN",
					"�-szlig",
					"�-agrave",
					"�-aacute",
					"�-acirc",
					"�-atilde",
					"�-auml",
					"�-aring",
					"�-aelig",
					"�-ccedil",
					"�-egrave",
					"�-eacute",
					"�-ecirc",
					"�-euml",
					"�-igrave",
					"�-iacute",
					"�-icirc",
					"�-iuml",
					"�-eth",
					"�-ntilde",
					"�-ograve",
					"�-oacute",
					"�-ocirc",
					"�-otilde",
					"�-ouml",
					"�-divide",
					"�-oslash",
					"�-ugrave",
					"�-uacute",
					"�-ucirc",
					"�-uuml",
					"�-yacute",
					"�-thorn",
					"�-yuml",
					"�-OElig",
					"�-oelig",
					"�-Scaron",
					"�-scaron",
					"�-Yuml",
					"�-fnof",
					"�-circ",
					"�-tilde",
					"?-Alpha",
					"?-Beta",
					"?-Gamma",
					"?-Delta",
					"?-Epsilon",
					"?-Zeta",
					"?-Eta",
					"?-Theta",
					"?-Iota",
					"?-Kappa",
					"?-Lambda",
					"?-Mu",
					"?-Nu",
					"?-Xi",
					"?-Omicron",
					"?-Pi",
					"?-Rho",
					"?-Sigma",
					"?-Tau",
					"?-Upsilon",
					"?-Phi",
					"?-Chi",
					"?-Psi",
					"?-Omega",
					"?-alpha",
					"?-beta",
					"?-gamma",
					"?-delta",
					"?-epsilon",
					"?-zeta",
					"?-eta",
					"?-theta",
					"?-iota",
					"?-kappa",
					"?-lambda",
					"?-mu",
					"?-nu",
					"?-xi",
					"?-omicron",
					"?-pi",
					"?-rho",
					"?-sigmaf",
					"?-sigma",
					"?-tau",
					"?-upsilon",
					"?-phi",
					"?-chi",
					"?-psi",
					"?-omega",
					"?-thetasym",
					"?-upsih",
					"?-piv",
					"\u2002-ensp",
					"\u2003-emsp",
					"\u2009-thinsp",
					"?-zwnj",
					"?-zwj",
					"?-lrm",
					"?-rlm",
					"�-ndash",
					"�-mdash",
					"�-lsquo",
					"�-rsquo",
					"�-sbquo",
					"�-ldquo",
					"�-rdquo",
					"�-bdquo",
					"�-dagger",
					"�-Dagger",
					"�-bull",
					"�-hellip",
					"�-permil",
					"?-prime",
					"?-Prime",
					"�-lsaquo",
					"�-rsaquo",
					"?-oline",
					"?-frasl",
					"�-euro",
					"?-image",
					"?-weierp",
					"?-real",
					"�-trade",
					"?-alefsym",
					"?-larr",
					"?-uarr",
					"?-rarr",
					"?-darr",
					"?-harr",
					"?-crarr",
					"?-lArr",
					"?-uArr",
					"?-rArr",
					"?-dArr",
					"?-hArr",
					"?-forall",
					"?-part",
					"?-exist",
					"?-empty",
					"?-nabla",
					"?-isin",
					"?-notin",
					"?-ni",
					"?-prod",
					"?-sum",
					"?-minus",
					"?-lowast",
					"?-radic",
					"?-prop",
					"?-infin",
					"?-ang",
					"?-and",
					"?-or",
					"?-cap",
					"?-cup",
					"?-int",
					"?-there4",
					"?-sim",
					"?-cong",
					"?-asymp",
					"?-ne",
					"?-equiv",
					"?-le",
					"?-ge",
					"?-sub",
					"?-sup",
					"?-nsub",
					"?-sube",
					"?-supe",
					"?-oplus",
					"?-otimes",
					"?-perp",
					"?-sdot",
					"?-lceil",
					"?-rceil",
					"?-lfloor",
					"?-rfloor",
					"?-lang",
					"?-rang",
					"?-loz",
					"?-spades",
					"?-clubs",
					"?-hearts",
					"?-diams"
				};
				private static readonly Dictionary<string, char> _lookupTable = WebUtility.HtmlEntities.GenerateLookupTable();
				private static Dictionary<string, char> GenerateLookupTable()
				{
					Dictionary<string, char> dictionary = new Dictionary<string, char>(StringComparer.Ordinal);
					string[] entitiesList = WebUtility.HtmlEntities._entitiesList;
					for (int i = 0; i < entitiesList.Length; i++)
					{
						string text = entitiesList[i];
						dictionary.Add(text.Substring(2), text[0]);
					}
					return dictionary;
				}
				public static char Lookup(string entity)
				{
					char result;
					WebUtility.HtmlEntities._lookupTable.TryGetValue(entity, out result);
					return result;
				}
			}
			private enum UnicodeDecodingConformance
			{
				Auto,
				Strict,
				Compat,
				Loose
			}

			private static readonly char[] _htmlEntityEndingChars = new char[] { ';', '&' };
			private static readonly UnicodeDecodingConformance _htmlDecodeConformance = UnicodeDecodingConformance.Compat;

			public static string HtmlDecode(string value)
			{
				if (string.IsNullOrEmpty(value))
				{
					return value;
				}
				if (!WebUtility.StringRequiresHtmlDecoding(value))
				{
					return value;
				}
				StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
				WebUtility.HtmlDecode(value, stringWriter);
				return stringWriter.ToString();
			}

			private static bool StringRequiresHtmlDecoding(string s)
			{
				if (WebUtility._htmlDecodeConformance == UnicodeDecodingConformance.Compat)
				{
					return s.IndexOf('&') >= 0;
				}
				for (int i = 0; i < s.Length; i++)
				{
					char c = s[i];
					if (c == '&' || char.IsSurrogate(c))
					{
						return true;
					}
				}
				return false;
			}

			private static void ConvertSmpToUtf16(uint smpChar, out char leadingSurrogate, out char trailingSurrogate)
			{
				int num = (int)(smpChar - 65536u);
				leadingSurrogate = (char)(num / 1024 + 55296);
				trailingSurrogate = (char)(num % 1024 + 56320);
			}

			public static void HtmlDecode(string value, TextWriter output)
			{
				if (value == null)
				{
					return;
				}
				if (output == null)
				{
					throw new ArgumentNullException("output");
				}
				if (!WebUtility.StringRequiresHtmlDecoding(value))
				{
					output.Write(value);
					return;
				}
				int length = value.Length;
				int i = 0;
				while (i < length)
				{
					char c = value[i];
					if (c != '&')
					{
						goto IL_1B6;
					}
					int num = value.IndexOfAny(WebUtility._htmlEntityEndingChars, i + 1);
					if (num <= 0 || value[num] != ';')
					{
						goto IL_1B6;
					}
					string text = value.Substring(i + 1, num - i - 1);
					if (text.Length > 1 && text[0] == '#')
					{
						uint num2;
						bool flag;
						if (text[1] == 'x' || text[1] == 'X')
						{
							flag = uint.TryParse(text.Substring(2), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out num2);
						}
						else
						{
							flag = uint.TryParse(text.Substring(1), NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out num2);
						}
						if (flag)
						{
							switch (WebUtility._htmlDecodeConformance)
							{
								case UnicodeDecodingConformance.Strict:
									flag = (num2 < 55296u || (57343u < num2 && num2 <= 1114111u));
									break;
								case UnicodeDecodingConformance.Compat:
									flag = (0u < num2 && num2 <= 65535u);
									break;
								case UnicodeDecodingConformance.Loose:
									flag = (num2 <= 1114111u);
									break;
								default:
									flag = false;
									break;
							}
						}
						if (!flag)
						{
							goto IL_1B6;
						}
						if (num2 <= 65535u)
						{
							output.Write((char)num2);
						}
						else
						{
							char value2;
							char value3;
							WebUtility.ConvertSmpToUtf16(num2, out value2, out value3);
							output.Write(value2);
							output.Write(value3);
						}
						i = num;
					}
					else
					{
						i = num;
						char c2 = WebUtility.HtmlEntities.Lookup(text);
						if (c2 != '\0')
						{
							c = c2;
							goto IL_1B6;
						}
						output.Write('&');
						output.Write(text);
						output.Write(';');
					}
					IL_1BD:
					i++;
					continue;
					IL_1B6:
					output.Write(c);
					goto IL_1BD;
				}
			}
		}
	}

