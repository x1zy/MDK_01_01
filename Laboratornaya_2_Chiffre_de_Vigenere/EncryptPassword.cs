using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Laboratornaya_2_Chiffre_de_Vigenere;

public class EncryptPassword
    {
        private List<char> _alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToList();
        private string _text;

        public EncryptPassword(string text)
        {
            _text = text;
        }

        private char EncryptChar(char character, int shift)
        {
            int index = _alphabet.IndexOf(char.ToUpper(character));
            if (index == -1) return character;

            int newIndex = index + shift;
            if (newIndex >= _alphabet.Count)
                newIndex -= _alphabet.Count;

            return char.IsUpper(character) ? _alphabet[newIndex] : char.ToLower(_alphabet[newIndex]);
        }

        private char DecryptChar(char character, int shift)
        {
            int index = _alphabet.IndexOf(char.ToUpper(character));
            if (index == -1) return character;

            int newIndex = index - shift;
            if (newIndex < 0)
                newIndex += _alphabet.Count;

            return char.IsUpper(character) ? _alphabet[newIndex] : char.ToLower(_alphabet[newIndex]);
        }

        public string Encrypt(string key)
        {
            string result = "";
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (var character in _text)
            {
                if (!_alphabet.Contains(char.ToUpper(character)))
                {
                    result += character;
                    continue;
                }

                int shift = _alphabet.IndexOf(key[keyIndex % key.Length]);
                result += EncryptChar(character, shift);
                keyIndex++;
            }

            return result;
        }

        public string Decrypt(string key)
        {
            string result = "";
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (var character in _text)
            {
                if (!_alphabet.Contains(char.ToUpper(character)))
                {
                    result += character;
                    continue;
                }

                int shift = _alphabet.IndexOf(key[keyIndex % key.Length]);
                result += DecryptChar(character, shift);
                keyIndex++;
            }

            return result;
        }
    }