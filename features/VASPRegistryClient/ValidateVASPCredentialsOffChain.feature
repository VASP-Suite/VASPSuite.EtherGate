Feature: Validate VASP credentials off-chain
  
  Scenario Outline: Calling ValidateCredentialsOffline method of a VASPRegistryClient
    When I call ValidateCredentialsOffline method of a VASPRegistryClient with a credentials from "<credentialsJsonPath>" and a following hash "<credentialsHash>"
    Then the ValidateCredentialsOffline call result should be "<result>"
    
    Examples:
    | credentialsJsonPath                    | credentialsHash                                                    | result |
    | Examples/Credentials/f00000000001.json | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | true   |
    | Examples/Credentials/f00000000001.json | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | false  |
    | Examples/Credentials/f00000000002.json | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | false  |
    | Examples/Credentials/f00000000002.json | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | true   |