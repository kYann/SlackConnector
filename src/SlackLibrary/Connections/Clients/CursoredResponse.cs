﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SlackLibrary.Connections.Clients
{
    public class CursoredResponse<V> : IEnumerable<V>
    {
		public CursoredResponse(IEnumerable<V> items, string nextCursor)
		{
			Items = items;
			NextCursor = nextCursor;
		}

		public string NextCursor { get; set; }

		public bool HasNextCursor() => !string.IsNullOrEmpty(this.NextCursor);

		public IEnumerable<V> Items { get; }

		public IEnumerator<V> GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}
	}
}
