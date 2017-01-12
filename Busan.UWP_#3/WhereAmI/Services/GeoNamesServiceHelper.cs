using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WhereAmI.Models;

namespace WhereAmI.Services
{
    public class GeoNamesServiceHelper
    {
        /// <summary>
        /// 싱글톤 인스턴스
        /// </summary>
        private static GeoNamesServiceHelper _instance;
        public static GeoNamesServiceHelper Instance
        {
            get { return _instance = _instance ?? new GeoNamesServiceHelper(); }
        }

        /// <summary>
        /// Geonames 조회
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<Rootobject> GetGeonames(string query)
        {
            if (string.IsNullOrEmpty(query)) return null;
            
            //username부분은 가입을 한 후에 사용해야 합니다.
            var uri = $"http://api.geonames.org/searchJSON?q={query}&maxRows=50&username=loveu012u";
            
            //서비스 호출
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(new Uri(uri));
                if (string.IsNullOrEmpty(result)) return null;
                
                //JSON데이터를 모델로 변환
                var resultRoot = JsonConvert.DeserializeObject<Rootobject>(result);
                return resultRoot;
            }
        }
    }
}
