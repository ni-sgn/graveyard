import fastapi as fa
import wallet_facade as wallet_facade
import typing
import configparser
import models.enums as enums
import hdwallet

import models.wallet_dto as wallet_dto

cfg : configparser.ConfigParser = configparser.ConfigParser()
settings = cfg.read('settings.cfg') 

port = cfg.get('Host', 'port')

app = fa.FastAPI()

@app.get(
    "/generate-wallet",
    responses={
        500: {"model": fa.openapi.models.Response,
             "description": "Internal Server Error",
              "content": {
                  "application/json": {
                      "example": {
                          "error": "Internal Server Error"
                        }
                    }
                }
            },
    }
) 
async def root(
        crypto : enums.SymbolEnum,
        strength : enums.StrengthEnum,
        language : enums.LanguageEnum,
        passphrase : typing.Optional[str]=None,
        index : int = 44,
        hardened : bool = True
        ):
    try:
        wallet = wallet_facade.HDWalletFacade(crypto, strength.value, language.value, passphrase, index, hardened)
        return wallet.derive_wallet()
    except Exception as ex:
        return fa.responses.JSONResponse(content={"error": str(ex)}, status_code=500)