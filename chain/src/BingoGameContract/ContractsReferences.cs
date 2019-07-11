using AElf;
using AElf.Contracts.Consensus.AEDPoS;
using AElf.Contracts.Genesis;
using AElf.Contracts.MultiToken.Messages;
using AElf.Sdk.CSharp.State;

namespace BingoGameContract
{
    public partial class BingoGameContractState
    {
        internal BasicContractZeroContainer.BasicContractZeroReferenceState BasicContractZero { get; set; }
        internal TokenContractContainer.TokenContractReferenceState TokenContract { get; set; }
        internal AEDPoSContractContainer.AEDPoSContractReferenceState ConsensusContract { get; set; }

        public SingletonState<AElf.Types.Hash> TokenContractSystemName { get; set; }
        public SingletonState<AElf.Types.Hash> ContractContractSystemName { get; set; }
    }
}