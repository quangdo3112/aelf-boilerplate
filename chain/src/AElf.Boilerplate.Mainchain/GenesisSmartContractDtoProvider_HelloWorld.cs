using System.Collections.Generic;
using System.Linq;
using Acs0;
using AElf.OS.Node.Application;
using AElf.Types;

namespace AElf.Blockchains.MainChain
{
    public partial class GenesisSmartContractDtoProvider
    {
        public IEnumerable<GenesisSmartContractDto> GetGenesisSmartContractDtosForHelloWorld(Address zeroContractAddress)
        {
            var l = new List<GenesisSmartContractDto>();

            l.AddGenesisSmartContract(
                _codes.Single(kv=>kv.Key.Contains("HelloWorld")).Value,
                Hash.FromString("AElf.ContractNames.HelloWorldContract"), new SystemContractDeploymentInput.Types.SystemTransactionMethodCallList());

            return l;
        }
    }
}