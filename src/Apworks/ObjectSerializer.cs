﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Apworks
{
    public abstract class ObjectSerializer : IObjectSerializer
    {
        public virtual TObject Deserialize<TObject>(byte[] data) => (TObject)this.Deserialize(typeof(TObject), data);

        public abstract object Deserialize(Type objType, byte[] data);

        public virtual Task<TObject> DeserializeAsync<TObject>(byte[] data, CancellationToken cancellationToken = default(CancellationToken))
            => Task.FromResult(Deserialize<TObject>(data));

        public virtual Task<object> DeserializeAsync(Type objType, byte[] data, CancellationToken cancellationToken = default(CancellationToken))
            => Task.FromResult(Deserialize(objType, data));

        public virtual byte[] Serialize<TObject>(TObject obj) => this.Serialize(typeof(TObject), obj);

        public abstract byte[] Serialize(Type objType, object obj);

        public virtual Task<byte[]> SerializeAsync<TObject>(TObject obj, CancellationToken cancellationToken = default(CancellationToken))
            => Task.FromResult(Serialize<TObject>(obj));

        public virtual Task<byte[]> SerializeAsync(Type objType, object obj, CancellationToken cancellationToken = default(CancellationToken))
            => Task.FromResult(Serialize(objType, obj));
    }
}
