# DistanceCalculator
.net core web api for calculating distance between two coordinates

Usages
[HttpGet("{latitude:double}/{longitude:double}/{otherlatitude:double}/{otherlongitude:double}")]
public IActionResult Get(double latitude, double longitude, double otherlatitude, double otherlongitude, CalculationType calcType = CalculationType.Haversine, UnitOfDistance unitOfDistance = UnitOfDistance.Km)
    


curl -X GET "https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1" -H  "accept: */*"
Request URL
https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1

Response body
{
  "distance": 5918.185064088762,
  "unitOfDistance": "Km"
}



curl -X GET "https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1?unitOfDistance=Miles" -H  "accept: */*"
Request URL
https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1?unitOfDistance=Miles

Response body
{
  "distance": 3677.3897077494307,
  "unitOfDistance": "Miles"
}



curl -X GET "https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1?calcType=Pythagoras&unitOfDistance=Km" -H  "accept: */*"
Request URL
https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1?calcType=Pythagoras&unitOfDistance=Km

Response body

{
  "distance": 78.13897874940521,
  "unitOfDistance": "Km"
}

curl -X GET "https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1?calcType=Pythagoras&unitOfDistance=Miles" -H  "accept: */*"
Request URL
https://localhost:44393/DistanceCalculator/51.5/0/38.8/-77.1?calcType=Pythagoras&unitOfDistance=Miles

Response body
{
  "distance": 48.553310367180586,
  "unitOfDistance": "Miles"
}
