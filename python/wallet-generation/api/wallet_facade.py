import hdwallet
import hdwallet.utils
import hdwallet.symbols
import typing

class HDWalletFacade():
    def __init__(self, symbol : str, strength : int, language : str, passphrase : str, index : int, hardened : bool):
        self._symbol : str = symbol
        self._strength : int = strength
        self._language : str = language 
        self._passphrase : typing.Optional[str] = passphrase
        self._index : int = index
        self._hardened : bool = hardened

        self._entropy : str = hdwallet.utils.generate_entropy(strength=self._strength) 
        self._hdwallet = hdwallet.HDWallet(symbol=self._symbol)
        self._hdwallet.from_entropy(entropy=self._entropy, language=self._language, passphrase=self._passphrase)

    def derive_wallet(self):
        self._hdwallet.from_index(self._index, hardened=self._hardened)
        return self._hdwallet.dumps()
    