using SuperSocket.Facility.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket.FunThingSuperSocket
{
    public class MyReceiveFilter:FixedHeaderReceiveFilter<MyRequestInfo>
    {
        public MyReceiveFilter() : base(4) { }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            return header[offset + 2] * 256 + header[offset + 3];
        }

        protected override MyRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            var body = bodyBuffer.Skip(offset).Take(length).ToArray();
            return new MyRequestInfo(header.Array,body);
        }
    }
}
