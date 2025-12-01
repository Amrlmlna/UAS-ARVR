# AR Speaker System - Augmented Reality Audio Experience

## Project Overview

This project is an Augmented Reality (AR) speaker system application developed using Unity and Vuforia SDK. The application allows users to place virtual speakers in the real environment using image targets and control music playback through interactive touch buttons. The system can play multiple audio tracks simultaneously across different speaker models, creating an immersive audio experience in augmented reality.

## Architecture

### Project Structure
```
My Project/
├── Assets/                 # Main project assets
│   ├── Editor/             # Editor-specific scripts and tools
│   ├── HQ Acoustic system/ # 3D models and materials for speaker systems
│   ├── Materials/          # Material assets
│   ├── Prefabs/            # Pre-built game objects
│   │   └── Ghost Models/   # Visual feedback models for placement
│   ├── Resources/          # Runtime-loadable assets
│   │   └── Music/          # Audio files
│   ├── Scenes/             # Unity scene files
│   ├── Scripts/            # C# script files
│   └── StreamingAssets/    # Assets copied to build without processing
├── Library/                # Unity-generated project data
├── Logs/                   # Build and runtime logs
├── Packages/               # Project packages and dependencies
├── ProjectSettings/        # Project configuration settings
├── QCAR/                   # Vuforia AR target data
├── Temp/                   # Temporary files
└── UserSettings/           # User-specific settings
```

### Core Components

#### Scripts
- **ARSpeakerManager.cs**: Main audio control system that manages music playback across multiple speakers
- **SimpleTouchButton.cs**: Handles touch interaction for play/pause functionality

#### Scenes
- **SampleScene.unity**: Main scene with three AR image targets (Speaker1, Speaker2, Speaker3) and virtual speakers

#### Assets and Prefabs
- **HQ Acoustic System**: 3D models of speaker components (Amplifier, Satellite speakers, Subwoofer)
- **Ghost Models**: Visual placeholders that appear during AR speaker placement
- **Prefabs**: Pre-configured speaker objects (Mid-Range Speaker, Speaker Tower, Subwoofer, etc.)

#### Audio Resources
- **Music Folder**: Contains audio tracks for playback (In Dreamland, Middle C, Orb Sound, etc.)

## Detailed Folder Information

### Assets Folder
The main content directory containing all project assets, scripts, and resources.

#### Editor
Contains Unity editor extensions and custom tools for the development workflow.

#### HQ Acoustic System
This folder contains 3D models of high-quality acoustic equipment:
- **FBX Models**: Amplifier.FBX, Satellite_center.FBX, Satellite_hight.FBX, Satellite_low.FBX, Subwoofer.FBX
- **Prefab Variants**: Prefab versions of each model ready for use in scenes
- **Textures**: Diffuse, normal, and specular texture maps for realistic materials

#### Materials
Contains material assets for visual rendering:
- **Dark.mat**: Dark colored material
- **Deep Black.mat**: Pure black material
- **Glass.mat**: Transparent glass material
- **Glow.mat**: Emissive glowing material
- **Temporary Material.mat**: Placeholder material

#### Prefabs
Pre-configured game objects that can be instantiated in scenes:
- **Ghost Models**: Visual feedback objects for AR placement
  - Ghost Midrange, Ghost Speaker Tower, Ghost Subwoofer, Ghost Tweeter
- **Interactive Elements**:
  - Edit Speaker UI, Music Queue Menu, Now Playing Menu
- **Speaker Objects**:
  - Mid-Range Speaker, Speaker Tower, Subwoofer, Tweeter
- **UI Elements**: Orb, Window prefabs

#### Resources
Assets loaded at runtime:
- **Music**: Contains all audio files used in the application
  - In Dreamland (Default Song).mp3
  - Middle C.mp3
  - Orb Sound.mp3
  - phaseSound.mp3
  - pop.mp3
  - Subwoofer Sound.mp3
  - White Noise.mp3

#### Scenes
Contains the main Unity scene:
- **SampleScene.unity**: Main AR application scene with camera, lights, and three image targets

#### Scripts
Application logic scripts:
- **ARSpeakerManager.cs**: Core audio management system
- **SimpleTouchButton.cs**: Touch interaction handling

#### StreamingAssets
Contains assets that are copied to builds without processing, typically used for data files or assets that need to remain in their original format.

### Library Folder
Unity-generated folder containing project build data and cached information. This folder should not be committed to version control.

### Logs Folder
Contains build and runtime logs for debugging purposes.

### Packages Folder
Contains Unity package dependencies including:
- **com.ptc.vuforia.engine-11.4.4.tgz**: Vuforia AR SDK
- **manifest.json**: Package dependencies and versions
- **packages-lock.json**: Locked package versions

### ProjectSettings Folder
Contains all project-specific settings, including:
- **VuforiaConfiguration.asset**: Vuforia AR settings and license key
- **AudioManager.asset**: Audio system configuration
- **GraphicsSettings.asset**: Graphics rendering settings
- **InputManager.asset**: Input system configuration
- Various other Unity engine settings

### QCAR Folder
Contains Vuforia AR target data and configuration files.

### Temp and UserSettings Folders
Temporary files and user-specific settings respectively. These are typically excluded from version control.

## Script Functionality

### ARSpeakerManager.cs
The primary audio controller script that:
- Loads music tracks from the Resources/Music folder at runtime
- Manages playback status (play/pause) across all active speakers
- Synchronizes track position when toggling play/pause
- Finds all GameObjects tagged as "Speakers" to control audio playback
- Maintains track time to ensure synchronized playback across multiple speakers

### SimpleTouchButton.cs
A simple interaction script that:
- Detects mouse/touch input on 3D objects
- Provides visual feedback by moving the button when pressed
- Calls the ARSpeakerManager to toggle music playback
- Communicates with the music manager to control audio

## Platform and Build Information

The project is configured for Android deployment:
- **Minimum SDK Version**: API 29 (Android 10)
- **Target Architecture**: ARM64
- **Application Identifier**: com.DefaultCompany.Myproject
- **Bundle Version**: 0.1

The project includes two APK files (UAS.apk, UAStes.apk) indicating completed builds for Android deployment.

## AR Capabilities

The application uses Vuforia AR SDK version 11.4.4 with:
- Image target recognition for speaker placement
- Three defined image targets (Speaker1, Speaker2, Speaker3)
- Ghost model visualization for speaker placement feedback
- Real-time rendering of 3D speaker models on recognized targets
- AR camera with background rendering

## Audio System

The audio implementation features:
- Runtime loading of audio files from Resources folder
- Synchronized playback across multiple speakers
- Position tracking to maintain synchronization
- Support for multiple speaker types with different audio characteristics

## Application Features

1. **Multi-speaker AR Audio**: Place multiple virtual speakers in real space
2. **Touch Controls**: Interactive buttons for play/pause functionality
3. **Synchronized Playback**: Audio tracks stay in sync across all speakers
4. **Runtime Music Loading**: Dynamically loads music from Resources folder
5. **Visual Feedback**: Ghost models provide placement guidance
6. **3D Audio Experience**: Immersive spatial audio in augmented reality

## Technical Dependencies

- Unity Engine (version based on installed template)
- Vuforia SDK 11.4.4
- Android Build Support
- ARCore (for Android AR functionality)

## Build Output

The project includes two APK files:
- **UAS.apk**: Final project build
- **UAStes.apk**: Test or development build

## Development Notes

The application was developed with focus on creating an immersive AR audio experience. The code includes Indonesian comments indicating it was developed for an Indonesian academic context. The AR targets are configured to recognize specific physical markers for speaker placement.

---

## Team Roles for Final Assignment

1. **Project Lead (Team Coordinator)**
   - Responsible for overall project management and coordination
   - Ensures all team members are working on their assigned tasks
   - Coordinates between different development aspects
   - Manages project timeline and deliverables
   - Handles communication with instructors and stakeholders

2. **AR Developer (Augmented Reality Specialist)**
   - Implements and maintains Vuforia AR functionality
   - Configures image targets and tracking systems
   - Optimizes AR performance and tracking accuracy
   - Handles AR-specific challenges like lighting estimation and plane detection
   - Tests AR functionality on different devices and lighting conditions

3. **Audio Systems Engineer**
   - Develops and maintains the audio playback system
   - Implements synchronization between multiple speakers
   - Optimizes audio loading and streaming
   - Ensures audio quality and performance across devices
   - Manages audio file formats and compression

4. **UI/UX Designer**
   - Designs user interfaces for the AR application
   - Creates intuitive touch controls for speaker interaction
   - Develops visual feedback systems for AR interactions
   - Focuses on user experience and ease of use
   - Implements visual design guidelines and consistency

5. **3D Model Specialist**
   - Creates and optimizes 3D models for speakers and UI elements
   - Ensures 3D models are optimized for mobile AR performance
   - Implements material and texture optimization
   - Works on visual effects like ghost models and animations
   - Manages 3D asset pipeline and quality

6. **Quality Assurance & Testing Lead**
   - Develops and executes testing plans for the AR application
   - Tests functionality across different devices and platforms
   - Identifies and documents bugs and issues
   - Performs user experience testing and gathers feedback
   - Ensures application stability and performance optimization