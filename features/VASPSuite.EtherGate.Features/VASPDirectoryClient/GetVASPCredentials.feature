Feature: Get VASP credentials

  Background:
    Given VASPDirectory smart contract was deployed
      And directory administrator added credentials from "Examples/Credentials/f00000000001.json" for the VASP with id "f00000000001"
      And then 100 blocks were mined
      And directory administrator added credentials from "Examples/Credentials/f00000000002.json" for the VASP with id "f00000000002"
    
  Scenario Outline: Calling GetCredentialsAsync method of VASPDirectoryClient
    When I call GetCredentialsAsync method of a VASPDirectoryClient with a following parameters: "<vaspId>", "<vaspCredentialsRef>", "<minimalConfirmationLevel>"
    Then the GetCredentialsAsync call should return credentials presented in "<credentialsJsonPath>"
    
    Examples:
    | vaspId       | vaspCredentialsRef                                                 | minimalConfirmationLevel | credentialsJsonPath                    |
    | f00000000001 | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | 0                        | Examples/Credentials/f00000000001.json |
    | f00000000001 | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | 100                      | Examples/Credentials/f00000000001.json |
    | f00000000002 | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | 0                        | Examples/Credentials/f00000000002.json |
    | f00000000002 | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | 100                      | Examples/Credentials/empty.json        |
    | f00000000002 | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | 0                        | Examples/Credentials/empty.json        |
    | f00000000003 | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | 0                        | Examples/Credentials/empty.json        |
    
  Scenario Outline: Calling TryGetCredentialsAsync method of VASPDirectoryClient
    When I call TryGetCredentialsAsync method of a VASPDirectoryClient with a following parameters: "<vaspId>", "<minimalConfirmationLevel>"
    Then the VASPIsRegistered property of the TryGetCredentialsAsync call result should be "<vaspIsRegistered>"
     And the Credentials property of the TryGetCredentialsAsync call result should be presented in "<credentialsJsonPath>"

    Examples:
    | vaspId       | minimalConfirmationLevel | vaspIsRegistered | credentialsJsonPath                    |
    | f00000000001 | 0                        | true             | Examples/Credentials/f00000000001.json |
    | f00000000001 | 100                      | true             | Examples/Credentials/f00000000001.json |
    | f00000000002 | 0                        | true             | Examples/Credentials/f00000000002.json |
    | f00000000002 | 100                      | false            | Examples/Credentials/empty.json        |
    | f00000000003 | 0                        | false            | Examples/Credentials/empty.json        |