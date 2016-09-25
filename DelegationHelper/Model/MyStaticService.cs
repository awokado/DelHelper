﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DelegationHelper.Model
{
    public static class MyStaticService
    {
        public static async Task<int> CountBytesInUrlAsync(string url)
        {
            // Artificial delay to show responsiveness.
            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);
            // Download the actual data and count it.
            using (var client = new HttpClient())
            {
                var data = await client.GetByteArrayAsync(url).ConfigureAwait(false);
                return data.Length;
            }
        }
    }
}
