using System.Collections.Generic;
using System.Linq;
using Acs0;
using AElf.Contracts.Vote;
using AElf.Kernel;
using AElf.Kernel.Token;
using AElf.OS.Node.Application;
using AElf.Types;

namespace AElf.Boilerplate.MainChain
{
    public partial class GenesisSmartContractDtoProvider
    {
        public IEnumerable<GenesisSmartContractDto> GetGenesisSmartContractDtosForVote(Address zeroContractAddress)
        {
            var l = new List<GenesisSmartContractDto>();
            l.AddGenesisSmartContract(
                _codes.Single(kv => kv.Key.Contains("Vote")).Value,
                VoteSmartContractAddressNameProvider.Name,
                new SystemContractDeploymentInput.Types.SystemTransactionMethodCallList());
            return l;
        }

        private SystemContractDeploymentInput.Types.SystemTransactionMethodCallList GenerateVoteInitializationCallList()
        {
            return new SystemContractDeploymentInput.Types.SystemTransactionMethodCallList();
        }
    }
}