import fastapi as fa
import wallet_facade as wallet_facade
import typing
import configparser
import models.enums as enums
import hdwallet

import models.wallet_dto as wallet_dto

cfg : configparser.ConfigParser = configparser.ConfigParser()
settings = cfg.read('settings.cfg') 

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
    wallet = wallet_facade.HDWalletFacade(crypto, strength, language, passphrase, index, hardened)
    return wallet.derive_wallet()