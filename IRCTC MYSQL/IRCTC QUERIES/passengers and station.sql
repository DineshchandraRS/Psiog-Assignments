USE MYDB;
SELECT passenger.PASSENGER_ID,passenger.userid,passenger.name,passenger.gender,passenger.seat,passenger.status,station.SOURCE ,station.DESTINATION,station.TRAINNUMBERS
FROM passenger
inner JOIN station ON passenger.PASSENGER_ID=station.passengerids
order by passenger.passenger_id;