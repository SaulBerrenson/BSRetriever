# BSRetriever
Library to retrive location from mobile networks information (cell tower | base stations) by MCC, MNC, LAC, CID or get location for BSSID Wi-Fi
Also you can retrive address from location and build link from location :)

# Features

Base Station Retrivers:
```
  -Myinakov
  -Yandex
  -Cell2Gps
  ```
  Wi-fi bssid Retrivers:
```
  -Myinakov
  -Yandex
```
  
Address Retrivers:
  ```
  -Nominatim
  ```
Link Builder:
```
  -Yandex
  -OSM
```
# Usage Base Station Retrivers

```
 [Fact]
        public void TestBS()
        {
           var retriver = new Retriver(("358","03", "3303333", "433523333398"))
               .withLink(new YandexLink())
               .withLocationRetriver(new RetriverMyinakov())
               .withRetriverAddress(new Nominatim());

           Assert.True(retriver.Retrive());
           Assert.Equal(retriver.Location, (60.0092613318, 30.26237712392));
           Assert.True(retriver.RetriveAddress());
           
           retriver.withLocationRetriver(new RetriverYandex());
           
           Assert.True(retriver.Retrive());
           Assert.True(retriver.RetriveAddress());
           
           Assert.Equal(retriver.Location, (60.0117645, 30.2631016));
           Assert.True(retriver.Retrive());
           Assert.Equal(retriver.Location, (60.0117645, 30.2631016));
        }
```
# Usage Wi-Fi bssid Retrivers

```
  [Fact]
        public void TestWifi()
        {

            var ret = new RetriverWifi("EE:43:F6:D1:B6:90")
                .withLink(new YandexLink())
                .withRetriverAddress(new Nominatim())
                .withLocationRetriver(new RetriverYandexWifi());

           Assert.True(ret.Retrive());

           Assert.Equal(ret.Location, (45.0387230, 39.0997925));

           ret.setData("00:0C:42:1F:65:E9")
               .withLocationRetriver(new RetriverMyinakovWifi());

           Assert.True(ret.Retrive());

           Assert.Equal(ret.Location, (45.22219677812, 16.54683275428));

        }
```

# Extantions
You can create your own retrivers just inherit from bases classes with pattern strategy


