using System.Collections.Generic;
using System.Linq;
using Acs0;
using AElf;
using AElf.Kernel;
using AElf.Kernel.Consensus;
using AElf.Kernel.Consensus.AEDPoS;
using AElf.Kernel.Token;
using AElf.OS.Node.Application;
using AElf.Types;
using BingoGameContract;

namespace AElf.Boilerplate.MainChain
{
    public partial class GenesisSmartContractDtoProvider
    {
        public IEnumerable<GenesisSmartContractDto> GetGenesisSmartContractDtosForBingoGame(Address zeroContractAddress)
        {
            var l = new List<GenesisSmartContractDto>();
            l.AddGenesisSmartContract(
                _codes.Single(kv => kv.Key.Contains("BingoGame")).Value,
                Hash.FromString("BingoGameContract"), GenerateElectionInitializationCallList());
            return l;
        }

        private SystemContractDeploymentInput.Types.SystemTransactionMethodCallList GenerateBingoGameInitializationCallList()
        {
            var bingoGameContractMethodCallList = new SystemContractDeploymentInput.Types.SystemTransactionMethodCallList();
            bingoGameContractMethodCallList.Add(nameof(BingoGameContract.BingoGameContract.InitialBingoGame),
                new InitialBingoGameInput
                {
                    TokenContractSystemName = TokenSmartContractAddressNameProvider.Name,
                    ConsensusContractSystemName = ConsensusSmartContractAddressNameProvider.Name
                });
            return bingoGameContractMethodCallList;
        }
    }
}