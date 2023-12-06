from enum import Enum
from hdwallet import symbols

class SymbolEnum(str, Enum):
    ETH = symbols.ETH
    BTC = symbols.BTC

class StrengthEnum(int, Enum):
    S128 : int = 128
    S160 : int = 160
    S192 : int = 192
    S224 : int = 224
    S256 : int = 256

class LanguageEnum(str, Enum):
    EN : str = 'english'
    KOR : str = 'korean'
