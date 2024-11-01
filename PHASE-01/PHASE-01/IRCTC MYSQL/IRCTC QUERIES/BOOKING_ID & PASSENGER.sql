use mydb;
select passenger.PASSENGER_ID,passenger.userid,passenger.userpassword,passenger.name,passenger.gender,passenger.seat,passenger.status
from passenger
inner join seats on passenger.PASSENGER_ID=seats.pasengers_ids
order by passenger.passenger_id;