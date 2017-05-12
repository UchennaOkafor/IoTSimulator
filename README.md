# IoTSimulator
[Description here]

https://github.com/uche1/things/

## Fetching data
[Description here]<br>
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
[Description here]<br>
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

### More
x
