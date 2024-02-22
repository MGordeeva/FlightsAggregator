# FlightsAggregator
Web api application for flights search

## Solution description
The solution consists of two main projects - web api and business. FlightAggregatorService in FlightsAggregator.Business project is responsible for working with the external services (IExternalService1, IExternalService2): aggregating search results and booking flights.

## Requests examples
GET /Flight?DepartureCity=tst&DestinationCity=tst&Date=2024-02-22&sortField=DepartureCity&acsending=true 
can be used for getting flights info

POST /Booking
{
  "passengersInfo": [
    {
      "firstName": "Andrew",
      "lastName": "White",
      "passportSeries": "111",
      "passportNumber": "111111",
      "citizenship": "US"
    }
  ],
  "externalServiceId": 1,
  "flightId": "123"
}
can be used for booking the flight