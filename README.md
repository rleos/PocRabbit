# PocRabbit

##### Small project to do a BrownBagLunch

## Configuration needed : 
  - Docker installed
  - RabbitMq running on localhost:5672
    - To do so, run the following command line : 
    ```docker run -d --name custom-rabbit -p 8080:15672 -p 5672:5672 rabbitmq:3-management```
    
## What's available 

  - Swagger for the server part at following adress : localhost:5001/swagger/index.html
  - Rabbit managment UI at localhost:8080
  
## What's next to add 

- [ ] Call specific Queues, Exchanges
- [ ] Security Policies : Retry, Circuit breaker
- [ ] Sage pattern, to chain messages
- [ ] Outbox pattern 
