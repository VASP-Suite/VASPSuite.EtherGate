Feature: Validate VASP credentials on-chain with a reference implementation of a VASP registry

  Background:
    Given VASPDirectory smart contract was deployed
  
  Scenario Outline: Calling ValidateCredentialsAsync method of a VASPDirectoryClient
    When I call ValidateCredentialsAsync method of a VASPRegistryClient with a credentials from "<credentialsJsonPath>" and a following hash "<credentialsHash>"
    Then the ValidateCredentialsAsync call result should be "<result>"

    Examples:
      | credentialsJsonPath                    | credentialsHash                                                    | result |
      | Examples/Credentials/f00000000001.json | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | true   |
      | Examples/Credentials/f00000000001.json | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | false  |
      | Examples/Credentials/f00000000002.json | 0x2a433539bb6f490f0e7f53e36708b65ea32ada9ba0660e37c8d74069a53ce89f | false  |
      | Examples/Credentials/f00000000002.json | 0x3fc752bf18130623d5bf4a85ab1575102d3ff8bf391d4dc4b18959c6a7a97491 | true   |