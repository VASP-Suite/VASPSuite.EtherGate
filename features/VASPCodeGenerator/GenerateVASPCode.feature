Feature: Generate VASP code

  Scenario: Calling GenerateVASPCode method of a VASPCodeGenerator
    When I call GenerateVASPCode method of a VASPCodeGenerator
    Then the GenerateVASPCode call result should be a VASP code