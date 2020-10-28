Feature: Check if VASP is registered in VASP index

  Background:
    Given VASPIndex smart contract was deployed
      And VASP with a code c28d7646 created a VASP contract with an address 0x23F66130a8808950AcD3956DB6092a4E19608D0A
      And then 100 blocks were mined
      And VASP with a code 5bf89160 created a VASP contract with an address 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8

  Scenario Outline: Calling VASPIsRegisteredAsync method of a VASPIndexClient and specifying VASP code
    When I call VASPIsRegisteredAsync method of a VASPIndexClient with a following parameters: "<vaspCode>", "<minimalConfirmationLevel>"
    Then the VASPIsRegisteredAsync call result should be "<vaspIsRegistered>"
    
    Examples:
    | vaspCode | minimalConfirmationLevel | vaspIsRegistered |
    | 5bf89160 | 0                        | true             |
    | 5bf89160 | 100                      | false            |
    | c28d7646 | 0                        | true             |
    | c28d7646 | 100                      | true             |
    | 4a86b7ba | 0                        | false            |
    | 4a86b7ba | 100                      | false            |

  Scenario Outline: Calling VASPIsRegisteredAsync method of a VASPIndexClient and specifying VASP contract address
    When I call VASPIsRegisteredAsync method of a VASPIndexClient with a following parameters: "<vaspContractAddress>", "<minimalConfirmationLevel>"
    Then the VASPIsRegisteredAsync call result should be "<vaspIsRegistered>"
    
    Examples:
    | vaspContractAddress                        | minimalConfirmationLevel | vaspIsRegistered |
    | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 | 0                        | true             |
    | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 | 100                      | false            |
    | 0x23F66130a8808950AcD3956DB6092a4E19608D0A | 0                        | true             |
    | 0x23F66130a8808950AcD3956DB6092a4E19608D0A | 100                      | true             |
    | 0x20f05C8D065d30a75bEd9919C10f812286F9935f | 0                        | false            |
    | 0x20f05C8D065d30a75bEd9919C10f812286F9935f | 100                      | false            |