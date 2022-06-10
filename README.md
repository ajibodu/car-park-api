

on a car approaching
-checks cars 
    if its a known car
        else create record
    if its claimed (has userId)
        then check if it has reservation
    inprocess a spot
    return carid/claimed/reservationid/spot

-car drive in
    update record in parking
    update parking_spot isbusy = true, inprocess = false 
    if reserved (set drive in)
    push notification to claimed user

--user booking from home
    get/set available slot and put inprocess
    get all cars by userid/phone
    select the car
    select reservation type (hour/day) with value
    log request to reservation
    update parking_spot reservation_id, isbusy = true, inprocess = false 

--drive out
    set DriveOutAt = current time
    timespent = DriveOutAt - DriveInAt
    check parking record
    if not reserved
        pay on spot
        
        
        
        
    
    

    
    