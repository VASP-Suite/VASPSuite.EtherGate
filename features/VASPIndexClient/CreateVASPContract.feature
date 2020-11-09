Feature: Create VASP contract

  Background:
    Given VASPIndex smart contract was deployed
  
  Scenario: Calling CreateVASPContractAsync method of a VASPIndexClient
    Given input parameter "owner" is set to "0x7d6dabD6B5C75291a3258C29B418f5805792a875"
      And input parameter "vaspCode" is set to "f314fa5e"
      And input parameter "channels" is set to "0x00000001"
      And input parameter "transportKey" is set to "0x025b40b4de302316d00591a36d49b4f96de0c16fe58f9c52319befda85d9ea43c2"
      And input parameter "messageKey" is set to "0x03afb3b241b76645c88f2d5d72442cb6d42cbf9eaed38aab157904261c7bca8dee"
      And input parameter "signingKey" is set to "0x0347970a7d0226ab2e68266a165e85a390933e4ecfbfaf6f4711e625e9f8d778f2"
      And input parameter "minimalConfirmationLevel" is set to "30"
    When I call CreateVASPContractAsync method of a VASPIndexClient with given parameters
    Then blockchain operation is started
     And blockchain operation is completed after 30 blocks