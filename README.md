# IoTSimulator
This application operates in conjunction with the [things](https://github.com/uche1/things/) web based application. The aim of this program is to simulate real life IoT devices.

## GUI
<img src="http://i.imgur.com/gIusxuC.png">

## Fetching data
When the program is turned on, it makes a GET request to the servers API endpoint requesting for a list of devices that are switched on. 
<br>
<b>GET</b>
/api/active_devices<br>
x
```json
[  
   {  
      "device_type":"Lightbulb",
      "id":2
   },
   {  
      "device_type":"Fridge",
      "id":4
   },
   {  
      "device_type":"Lightbulb",
      "id":9
   },
   {  
      "device_type":"Lightbulb",
      "id":10
   },
   {  
      "device_type":"Thermostat",
      "id":11
   },
   {  
      "device_type":"Smart Meter",
      "id":13
   }
]
```

## Simulating data
The program will then create an array of  devices based on the device type of each JSON object and it will periodically simulate data for each device type.
<br>
<b>POST</b>
/api/simulate/<br>
x
```json
[  
   {  
      "user_device_id":2,
      "raw_data":"{\"luminance\":19.7,\"wattage\":60.0}"
   },
   {  
      "user_device_id":4,
      "raw_data":"{\"fridge_temperature\":0.70000000000000007,\"freezer_temperature\":-3.8000000000000003}"
   },
   {  
      "user_device_id":9,
      "raw_data":"{\"luminance\":19.7,\"wattage\":60.0}"
   },
   {  
      "user_device_id":10,
      "raw_data":"{\"luminance\":19.7,\"wattage\":60.0}"
   },
   {  
      "user_device_id":11,
      "raw_data":"{\"room_temperature\":17.0,\"battery_level\":93}"
   },
   {  
      "user_device_id":13,
      "raw_data":"{\"electricity_used\":633.59999999999991,\"gas_used\":867.40000000000009}"
   }
]
```
