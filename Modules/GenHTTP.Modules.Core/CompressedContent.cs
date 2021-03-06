﻿using GenHTTP.Api.Infrastructure;
using GenHTTP.Modules.Core.Compression;

namespace GenHTTP.Modules.Core
{
    
    public static class CompressedContent
    {

        #region Builder

        public static CompressionConcernBuilder Empty() => new CompressionConcernBuilder();

        public static CompressionConcernBuilder Default()
        {
            return new CompressionConcernBuilder().Add(new BrotliCompression())
                                                  .Add(new GzipAlgorithm());
        }

        #endregion

        #region Extensions

        public static IServerHost Compression(this IServerHost host, CompressionConcernBuilder compression)
        {
            host.Add(compression);
            return host;
        }

        public static IServerHost Compression(this IServerHost host) => host.Compression(Default());

        #endregion

    }

}
