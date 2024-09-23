﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JWTApplication
{
    public static class JWTHelper
    {
        public static string GenerateToken(Header header, Payload payload, string secretKey)
        {
            var payloadSer = JsonConvert.SerializeObject(payload);
            var headerSer = JsonConvert.SerializeObject(header);

            var headerBase64 = Base64UrlEncode(headerSer);
            var payloadBase64 = Base64UrlEncode(payloadSer);

            var signatureBase64 = GenerateSignature(headerBase64, payloadBase64, secretKey);

            return $"{headerBase64}.{payloadBase64}.{signatureBase64}";
        }

        public static string Base64UrlEncode(string stringToDecode)
        {
            var bytes = Encoding.UTF8.GetBytes(stringToDecode);

            return Base64UrlEncode(bytes);
        }

        public static string Base64UrlEncode(byte[] bytes)
        {
            var base64 = Convert.ToBase64String(bytes);

            var baseURL = base64.TrimEnd('=').Replace('+', '-').Replace('/', '_');
            return baseURL;
        }

        public static string GenerateSignature(string headerBase64, string payloadBase64, string secretKey)
        {
            var cipherText = $"{headerBase64}.{payloadBase64}";
            HMACSHA256 hMACSHA256 = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var hashResult = hMACSHA256.ComputeHash(Encoding.UTF8.GetBytes(cipherText));

            return Base64UrlEncode(hashResult);

        }
    }
}
