using System.IO;
using Acs0;
using AElf;
using AElf.Contracts.BingoGameContract;
using AElf.Contracts.Consensus.AEDPoS;
using AElf.Contracts.Genesis;
using AElf.Contracts.TestKit;
using AElf.Cryptography.ECDSA;
using AElf.Kernel;
using AElf.Kernel.Consensus;
using AElf.OS.Node.Application;
using AElf.Types;
using Google.Protobuf;
using Volo.Abp.Threading;

namespace BingoGameContract.Test 
{
    public class BingoGameContractTestBase : ContractTestBase<BingoGameContractTestModule>
    {
        protected ECKeyPair BootMinerKeyPair => SampleECKeyPairs.KeyPairs[0];

        protected Address BingoGameContractAddress { get; set; }
        
        internal BasicContractZeroContainer.BasicContractZeroStub BasicContractZeroStub { get; set; }
        internal BingoGameContractContainer.BingoGameContractStub BingoContractStub { get; set; }

        public BingoGameContractTestBase()
        {
            BingoContractStub = GetBingoContractTester(BootMinerKeyPair);
        }
        
        internal BasicContractZeroContainer.BasicContractZeroStub GetContractZeroTester(ECKeyPair keyPair)
        {
            return GetTester<BasicContractZeroContainer.BasicContractZeroStub>(ContractZeroAddress, keyPair);
        }

        internal BingoGameContractContainer.BingoGameContractStub GetBingoContractTester(ECKeyPair keyPair)
        {
            return GetTester<BingoGameContractContainer.BingoGameContractStub>(BingoGameContractAddress, keyPair);
        }

        private SystemContractDeploymentInput.Types.SystemTransactionMethodCallList GenerateBingoContractMethodCallList()
        {
            var callList = new SystemContractDeploymentInput.Types.SystemTransactionMethodCallList();
            callList.Add(nameof(BingoGameContractContainer.BingoGameContractStub.InitialBingoGame), new InitialBingoGameInput
            {
                ConsensusContractSystemName = ConsensusSmartContractAddressNameProvider.Name,
                TokenContractSystemName = TokenConverterSmartContractAddressNameProvider.Name
            });
            return callList;
        }
    }
}