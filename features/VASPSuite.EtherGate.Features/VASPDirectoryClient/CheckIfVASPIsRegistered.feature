Feature: Check if VASP is registered in a VASP registry

  Background:
    Given VASPDirectory smart contract was deployed
      And directory administrator added credentials from "Examples/Credentials/f00000000001.json" for the VASP with id "f00000000001"
      And then 100 blocks were mined
      And directory administrator added credentials from "Examples/Credentials/f00000000002.json" for the VASP with id "f00000000002"

  Scenario Outline: Calling VASPIsRegisteredAsync method of VASPDirectoryClient
    When I call VASPIsRegisteredAsync method of a VASPDirectoryClient with a following parameters: "<vaspId>", "<minimalConfirmationLevel>"
    Then the VASPIsRegisteredAsync call result should be "<vaspIsRegistered>"

    Examples:
      | vaspId       | minimalConfirmationLevel | vaspIsRegistered |
      | f00000000001 | 100                      | true             |
      | f00000000001 | 0                        | true             |
      | f00000000002 | 100                      | false            |
      | f00000000002 | 0                        | true             |
      | f00000000003 | 100                      | false            |
      | f00000000003 | 0                        | false            |