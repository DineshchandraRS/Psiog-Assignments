USE MYDB;
SELECT PASSENGER_ID,name,passenger.GENDER,seat,status,userid,creator.FIRSTNAME,creator.LASTNAME,creator.GMAIL,creator.MOBILE,creator.STATE,creator.ADDRESS
from passenger
inner join creator on passenger.PASSENGER_ID=creator.PASSENGERSIDS
order by PASSENGER_ID;

