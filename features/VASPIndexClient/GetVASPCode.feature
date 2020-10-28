Feature: Get VASP code
  
  Background: 
    Given VASPIndex smart contract was deployed
      And VASP with a code c28d7646 created a VASP contract with an address 0x23F66130a8808950AcD3956DB6092a4E19608D0A
      And then 100 blocks were mined
      And VASP with a code 5bf89160 created a VASP contract with an address 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8
 
  Scenario Outline: Calling GetVASPCodeAsync method of a VASPIndexClient
    When I call GetVASPCodeAsync method of a VASPIndexClient with a following parameters: "<vaspContractAddress>", "<minimalConfirmationLevel>"
    Then the GetVASPCodeAsync call result should be "<vaspCode>"
    
    Examples:
    | vaspContractAddress                        | minimalConfirmationLevel | vaspCode |
    | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 | 0                        | 5bf89160 |
    | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 | 100                      | 00000000 |
    | 0x23F66130a8808950AcD3956DB6092a4E19608D0A | 0                        | c28d7646 |
    | 0x23F66130a8808950AcD3956DB6092a4E19608D0A | 100                      | c28d7646 |
    | 0x20f05C8D065d30a75bEd9919C10f812286F9935f | 0                        | 00000000 |
  
  Scenario Outline: Calling TryGetVASPCodeAsync method of a VASPIndexClient
    When I call TryGetVASPCodeAsync method of a VASPIndexClient with a following parameters: "<vaspContractAddress>", "<minimalConfirmationLevel>"
    Then the TryGetVASPCodeAsync call result should be ("<vaspIsRegistered>", "<vaspCode>")

    Examples:
    | vaspContractAddress                        | minimalConfirmationLevel | vaspIsRegistered | vaspCode |
    | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 | 0                        | true             | 5bf89160 |
    | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 | 100                      | false            | 00000000 |
    | 0x23F66130a8808950AcD3956DB6092a4E19608D0A | 0                        | true             | c28d7646 |
    | 0x23F66130a8808950AcD3956DB6092a4E19608D0A | 100                      | true             | c28d7646 |
    | 0x20f05C8D065d30a75bEd9919C10f812286F9935f | 0                        | false            | 00000000 |