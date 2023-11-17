from flask import Flask
import pyodbc

drivers = [item for item in pyodbc.drivers()]
driver = drivers[-1]
print("driver:{}".format(driver))
server = 'localhost'
database = 'university'
uid = 'SA'
pwd = 'P@ssw0rd'
con_string = f'DRIVER={driver};SERVER={server};DATABASE={database};UID={uid};PWD={pwd};TrustServerCertificate=yes;'
print(con_string)

cnxn = pyodbc.connect(con_string)

app = Flask(__name__)


@app.route("/", methods=['GET'])
def hello():
    return 'hello world'

if __name__ == '__main__':
    app.run(debug=True, port=8000)


# p value vs confirmation
# likelihood zomavs hipotezis empiriul shinaars

# p value fiqrobs shesadzlo mtkicebulebebze
# baysianism -> shesadzlo alternativebze
# frequentism has a problem of a threshold ( p value = 0.05 might not be
# that good)
# alilebs postulirebs 
# empiriuli shinaari ar aqvs notH, amitom ver shevadarebt H da notH

# kavshiri rwmenis xarisxebsa da samartlian tanxas shoris
# tu mivigebt ragac dashvebebs (imas, rom 
# tu tavtologiis cheshmaritebaze rame tanxas shemomtavazeben yoveltvis mogebashi
# 

# HD -> yvela tipis gamomdinareoba ar aris konfirmacia (Hypothetico-deductive??)
# hipoteza rom an iwvimebs an ara, am shemtxvevashi konfirmacia ar axdens wvima
# rogorc mtkicebuleba;
