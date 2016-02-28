﻿/***********************************************************************
Copyright 2016 Stefan Hausotte

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*************************************************************************/

using System.Text;

namespace PeNet.Structures
{
    public class IMAGE_FILE_HEADER
    {
        private readonly byte[] _buff;
        private readonly uint _offset;

        public IMAGE_FILE_HEADER(byte[] buff, uint offset)
        {
            _buff = buff;
            _offset = offset;
        }

        /// <summary>
        ///     I386: 0x014c
        ///     ARMv7: 0x1c4
        ///     AMD64: 0x8664
        /// </summary>
        public ushort Machine
        {
            get { return Utility.BytesToUInt16(_buff, _offset); }
            set { Utility.SetUInt16(value, _offset, _buff); }
        }

        public ushort NumberOfSections
        {
            get { return Utility.BytesToUInt16(_buff, _offset + 0x2); }
            set { Utility.SetUInt16(value, _offset + 0x2, _buff); }
        }

        public uint TimeDateStamp
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x4); }
            set { Utility.SetUInt32(value, _offset + 0x4, _buff); }
        }

        public uint PointerToSymbolTable
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0x8); }
            set { Utility.SetUInt32(value, _offset + 0x8, _buff); }
        }

        public uint NumberOfSymbols
        {
            get { return Utility.BytesToUInt32(_buff, _offset + 0xC); }
            set { Utility.SetUInt32(value, _offset + 0xC, _buff); }
        }

        public ushort SizeOfOptionalHeader
        {
            get { return Utility.BytesToUInt16(_buff, _offset + 0x10); }
            set { Utility.SetUInt16(value, _offset + 0x10, _buff); }
        }

        public ushort Characteristics
        {
            get { return Utility.BytesToUInt16(_buff, _offset + 0x12); }
            set { Utility.SetUInt16(value, _offset + 0x12, _buff); }
        }

        public override string ToString()
        {
            var sb = new StringBuilder("IMAGE_FILE_HEADER\n");
            sb.Append(Utility.PropertiesToString(this, "{0,-15}:\t{1,10:X}\n"));
            return sb.ToString();
        }
    }
}