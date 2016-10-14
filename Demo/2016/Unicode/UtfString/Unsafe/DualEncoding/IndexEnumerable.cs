﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace UtfString.Unsafe.DualEncoding
{
    public struct IndexEnumerable : IEnumerator<Index>, IEnumerable<Index>, IIndexEnumerable<Index, IndexEnumerable>
    {
        private readonly ArrayAccessor _buffer;
        private Index _i;

        public IndexEnumerable(ArrayAccessor buffer)
        {
            _buffer = buffer;
            _i = default(Index);
        }

        public Index Current => _i;
        public bool MoveNext()
        {
            _i.index += _i.wordCount;
            return Decoder.TryGetCount(_buffer, _i.index, out _i.wordCount);
        }

        object IEnumerator.Current => Current;
        void IDisposable.Dispose() { }
        void IEnumerator.Reset() { throw new NotSupportedException(); }

        public IndexEnumerable GetEnumerator() => new IndexEnumerable(_buffer);
        IEnumerator<Index> IEnumerable<Index>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
