Feature: Get VASP contract address

  Background:
    Given VASPIndex smart contract was deployed
      And VASP with a code c28d7646 created a VASP contract with an address 0x23F66130a8808950AcD3956DB6092a4E19608D0A
      And then 100 blocks were mined
      And VASP with a code 5bf89160 created a VASP contract with an address 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8

  Scenario Outline: Calling GetVASPContractAddressAsync method of a VASPIndexClient
    When I call GetVASPContractAddressAsync method of a VASPIndexClient with a following parameters: "<vaspCode>", "<minimalConfirmationLevel>"
    Then the GetVASPContractAddressAsync call result should be "<vaspContractAddress>"

    Examples:
    | vaspCode | minimalConfirmationLevel | vaspContractAddress                        |
    | 5bf89160 | 0                        | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 |
    | 5bf89160 | 100                      | 0x0000000000000000000000000000000000000000 |
    | c28d7646 | 0                        | 0x23F66130a8808950AcD3956DB6092a4E19608D0A |
    | c28d7646 | 100                      | 0x23F66130a8808950AcD3956DB6092a4E19608D0A |
    | 4a86b7ba | 0                        | 0x0000000000000000000000000000000000000000 |

  Scenario Outline: Calling TryGetVASPContractAddressAsync method of a VASPIndexClient
    When I call TryGetVASPContractAddressAsync method of a VASPIndexClient with a following parameters: "<vaspCode>", "<minimalConfirmationLevel>"
    Then the TryGetVASPContractAddressAsync call result should be ("<vaspIsRegistered>", "<vaspContractAddress>")

    Examples:
    | vaspCode | minimalConfirmationLevel | vaspIsRegistered | vaspContractAddress                        |
    | 5bf89160 | 0                        | true             | 0xD6C3FE9953074Db4a29Cc5aDb1d101b51236bBB8 |
    | 5bf89160 | 100                      | false            | 0x0000000000000000000000000000000000000000 |
    | c28d7646 | 0                        | true             | 0x23F66130a8808950AcD3956DB6092a4E19608D0A |
    | c28d7646 | 100                      | true             | 0x23F66130a8808950AcD3956DB6092a4E19608D0A |
    | 4a86b7ba | 0                        | false            | 0x0000000000000000000000000000000000000000 |