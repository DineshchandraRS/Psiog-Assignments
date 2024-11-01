use mydb;
select train.ADMINSID,train.DESTINATION,train.DEPARTURE_DAY,train.TRAIN_NAME,train.TRAIN_TYPE,payment.BOOKING_ID,payment.PASS_ID,payment.PAYMENT_MODE,payment.TRAINNUMBERSSSSS
from train
inner join payment on payment.TRAINNUMBERSSSSS=train.TRAIN_NUMBER
order by TRAIN_NUMBER;