namespace BinaryDataDecoders.Archives.Zip
{
    public enum CompressionMethodType : short
    {
        /*
          compression method: (2 bytes)
          (see accompanying documentation for algorithm descriptions)

          0 - The file is stored (no compression)
          1 - The file is Shrunk
          2 - The file is Reduced with compression factor 1
          3 - The file is Reduced with compression factor 2
          4 - The file is Reduced with compression factor 3
          5 - The file is Reduced with compression factor 4
          6 - The file is Imploded
          7 - Reserved for Tokenizing compression algorithm
          8 - The file is Deflated
          9 - Enhanced Deflating using Deflate64(tm)
         10 - PKWARE Data Compression Library Imploding (old IBM TERSE)
         11 - Reserved by PKWARE
         12 - File is compressed using BZIP2 algorithm
         13 - Reserved by PKWARE
         14 - LZMA (EFS)
         15 - Reserved by PKWARE
         16 - Reserved by PKWARE
         17 - Reserved by PKWARE
         18 - File is compressed using IBM TERSE (new)
         19 - IBM LZ77 z Architecture (PFS)
         97 - WavPack compressed data
         98 - PPMd version I, Rev 1
        */
        None = 0,
        Shrunk = 1,
        Factor1 = 2,
        Factor2 = 3,
        Factor3 = 4,
        Factor4 = 5,
        Imploded = 6,
        Tokenized = 7,
        Deflate = 8,
        Deflate64 = 9,
        IbmTerseOld = 10,
        Reserved11 = 11,
        BZIP2 = 12,
        Reserved13 = 13,
        LZMA = 14,
        Reserved15 = 15,
        Reserved16 = 16,
        Reserved17 = 17,
        IbmTerseNew = 18,
        IbmLZ77z = 19,
        WavPack = 97,
        PPMdv1r1 = 98

    }
}
