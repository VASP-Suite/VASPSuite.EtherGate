Feature: Get VASP credentials reference and hash

  Background:
    Given VASPDirectory smart contract was deployed
      And directory administrator added credentials from "Examples/Credentials/f00000000001.json" for the VASP with id "f00000000001"
      And then 100 blocks were mined
      And directory administrator added credentials from "Examples/Credentials/f00000000002.json" for the VASP with id "f00000000002"

  Scenario Outline: Calling GetCredentialsRefAndHashAsync method of VASPDirectoryClient
    When I call GetCredentialsRefAndHashAsync method of a VASPDirectoryClient with a following parameters: "<vaspId>", "<minimalConfirmationLevel>"
    Then the Ref property of the GetCredentialsRefAndHashAsync call result should be "<vaspCredentialsRef>"
     And the Hash property of the GetCredentialsRefAndHashAsync call result should be "<vaspCredentialsHash>"

    Examples:
    | vaspId       | minimalConfirmationLevel | vaspCredentialsRef                                                 | vaspCredentialsHash                                                |
    | f00000000001 | 100                      | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f |
    | f00000000001 | 0                        | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f |
    | f00000000002 | 100                      |                                                                    | 0x0000000000000000000000000000000000000000000000000000000000000000 |
    | f00000000002 | 0                        | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 |
    | f00000000003 | 100                      |                                                                    | 0x0000000000000000000000000000000000000000000000000000000000000000 |
    | f00000000003 | 0                        |                                                                    | 0x0000000000000000000000000000000000000000000000000000000000000000 |

  Scenario Outline: Calling TryGetCredentialsRefAndHashAsync method of VASPDirectoryClient
    When I call TryGetCredentialsRefAndHashAsync method of a VASPDirectoryClient with a following parameters: "<vaspId>", "<minimalConfirmationLevel>"
    Then the VASPIsRegistered property of the TryGetCredentialsRefAndHashAsync call result should be "<vaspIsRegistered>"
     And the VASPCredentialsRefAndHash property of the TryGetCredentialsRefAndHashAsync call result should be ("<vaspCredentialsRef>", "<vaspCredentialsHash>")

    Examples:
    | vaspId       | minimalConfirmationLevel | vaspIsRegistered | vaspCredentialsRef                                                 | vaspCredentialsHash                                                |
    | f00000000001 | 100                      | true             | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f |
    | f00000000001 | 0                        | true             | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f |
    | f00000000002 | 100                      | false            |                                                                    | 0x0000000000000000000000000000000000000000000000000000000000000000 |
    | f00000000002 | 0                        | true             | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 |
    | f00000000003 | 100                      | false            |                                                                    | 0x0000000000000000000000000000000000000000000000000000000000000000 |
    | f00000000003 | 0                        | false            |                                                                    | 0x0000000000000000000000000000000000000000000000000000000000000000 |