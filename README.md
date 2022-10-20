# currencyConverter

Armando Zerpa
For questions: ajzerpa@gmail.com

It have swagger for the endpoints.


Basic Auth:
username: admin
password: admin

----------------
some simple curls for testing

curl --location --request GET 'http://localhost:5188/api/currencies/usd'


curl --location --request GET 'http://localhost:5188/api/currencies/'


curl --location --request GET 'http://localhost:5188/api/currencies/historic/5'


curl --location --request POST 'http://localhost:5188/api/currencies' \
--header 'Content-Type: application/json' \
--data-raw '{
    "BaseCurrency": "AZB",
    "Date": "2022-10-01",
    "Exchanges": {
        "USD": 1.0,
        "EUR": 2.0
    }
}'


